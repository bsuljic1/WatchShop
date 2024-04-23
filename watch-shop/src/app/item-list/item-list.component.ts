import { Component, Input, OnInit, EventEmitter, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Brand } from '../shared/models/brand.model';
import { Color } from '../shared/models/color.model';
import { Condition } from '../shared/models/condition.model';
import { Filter } from '../shared/models/filter.model';
import { Gender } from '../shared/models/gender.model';
import { Style } from '../shared/models/style.model';
import { Watch } from '../shared/models/watch.model';
import { BrandService } from '../shared/services/brand.service';
import { ColorService } from '../shared/services/color.service';
import { ConditionService } from '../shared/services/condition.service';
import { GenderService } from '../shared/services/gender.service';
import { StyleService } from '../shared/services/style.service';
import { WatchService } from '../shared/services/watch.service';

@Component({
  selector: 'app-item-list',
  templateUrl: './item-list.component.html',
  styleUrls: ['./item-list.component.css'],
  providers: [WatchService],
})
export class ItemListComponent implements OnInit {
  watches: Watch[];
  @Input() filterContract: EventEmitter<Filter>;
  @Input() filterCategory: EventEmitter<Filter>;
  page: number;
  totalSize: number;

  brands: Brand[];
  styles: Style[];
  colors: Color[];
  conditions: Condition[];
  genders: Gender[];

  searchForm: FormGroup = new FormGroup({
    search: new FormControl(),
  });

  selectedSort: string;

  constructor(
    private watchService: WatchService,
    private brandService: BrandService,
    private styleService: StyleService,
    private colorService: ColorService,
    private conditionService: ConditionService,
    private genderService: GenderService,
    private router: Router
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
    this.watchService.getWatches().subscribe((response: Watch[]) => {
      this.watches = response;
      this.totalSize = this.watches.length;
    });
    this.page = 1;
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

  getWatches(filter: Filter) {
    this.watchService
      .getWatchesByFilter(filter)
      .subscribe((response: Watch[]) => {
        this.watches = response;
        this.totalSize = this.watches.length;
      });
  }

  doSearch() {
    let filter = new Filter(
      '',
      '',
      '',
      0,
      100000,
      '',
      '',
      this.searchForm.value.search,
      ''
    );
    this.watchService
      .getWatchesByFilter(filter)
      .subscribe((response: Watch[]) => {
        this.watches = response;
        this.totalSize = this.watches.length;
      });
  }

  sortBy(sortName: string) {
    console.log(sortName);
    let filter = new Filter('', '', '', 0, 100000, '', '', '', sortName);
    this.watchService
      .getWatchesByFilter(filter)
      .subscribe((response: Watch[]) => {
        this.watches = response;
        console.log(response);
        this.totalSize = this.watches.length;
      });
  }
}
