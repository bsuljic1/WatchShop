import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { Brand } from '../shared/models/brand.model';
import { Color } from '../shared/models/color.model';
import { Condition } from '../shared/models/condition.model';
import { Filter } from '../shared/models/filter.model';
import { Gender } from '../shared/models/gender.model';
import { Style } from '../shared/models/style.model';
import { User } from '../shared/models/user.model';
import { BrandService } from '../shared/services/brand.service';
import { ColorService } from '../shared/services/color.service';
import { ConditionService } from '../shared/services/condition.service';
import { GenderService } from '../shared/services/gender.service';
import { StyleService } from '../shared/services/style.service';
import { UserService } from '../shared/services/user.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
  providers: [
    BrandService,
    StyleService,
    ColorService,
    ConditionService,
    GenderService,
  ],
})
export class HeaderComponent implements OnInit {
  currentUser: User = JSON.parse(localStorage.getItem('currentUser'));
  brands: Brand[];
  styles: Style[];
  colors: Color[];
  conditions: Condition[];
  genders: Gender[];
  @Output() filterCategory = new EventEmitter<Filter>();

  constructor(
    private brandService: BrandService,
    private styleService: StyleService,
    private colorService: ColorService,
    private conditionService: ConditionService,
    private genderService: GenderService,
    private router: Router,
    private userService: UserService
  ) {}

  ngOnInit(): void {
    this.brandService.getBrands().subscribe((response: Brand[]) => {
      this.brands = response;
    });
    this.styleService.getStyles().subscribe((response: Style[]) => {
      this.styles = response;
    });
    this.colorService.getColors().subscribe((response: Color[]) => {
      this.colors = response;
    });
    this.conditionService.getConditions().subscribe((response: Condition[]) => {
      this.conditions = response;
    });
    this.genderService.getGenders().subscribe((response: Gender[]) => {
      this.genders = response;
    });
    this.userService.currentUserEmitter.subscribe(
      (res) => (this.currentUser = res)
    );
  }

  displayFilter(filter: string, filterName: string) {
    this.router.navigateByUrl('/products').then(() => {
      if (filter == 'Gender') {
        this.filterCategory.emit(
          new Filter(filterName, '', '', 0, 100000, '', '', '', '')
        );
      } else if (filter == 'Brand') {
        this.filterCategory.emit(
          new Filter('', filterName, '', 0, 100000, '', '', '', '')
        );
      } else {
        this.filterCategory.emit(
          new Filter('', '', '', 0, 100000, '', '', filterName, '')
        );
      }
    });
  }

  logout() {
    this.userService.logout();
  }
}
