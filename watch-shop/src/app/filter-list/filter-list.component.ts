import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Brand } from '../shared/models/brand.model';
import { BrandService } from '../shared/services/brand.service';
import { Color } from '../shared/models/color.model';
import { ColorService } from '../shared/services/color.service';
import { Style } from '../shared/models/style.model';
import { StyleService } from '../shared/services/style.service';
import { Condition } from '../shared/models/condition.model';
import { ConditionService } from '../shared/services/condition.service';
import { Gender } from '../shared/models/gender.model';
import { GenderService } from '../shared/services/gender.service';
import { FormGroup, FormControl } from '@angular/forms';
import { Filter } from '../shared/models/filter.model';

@Component({
  selector: 'app-filter-list',
  templateUrl: './filter-list.component.html',
  styleUrls: ['./filter-list.component.css'],
  providers: [
    BrandService,
    StyleService,
    ColorService,
    ConditionService,
    GenderService,
  ],
})
export class FilterListComponent implements OnInit {
  brands: Brand[];
  styles: Style[];
  colors: Color[];
  conditions: Condition[];
  genders: Gender[];

  brandView: boolean = false;
  genderView: boolean = false;
  conditionView: boolean = false;
  styleView: boolean = false;
  colorView: boolean = false;

  genderForm: FormGroup = new FormGroup({
    gender: new FormControl(),
  });
  brandForm: FormGroup = new FormGroup({
    brand: new FormControl(),
  });
  conditionForm: FormGroup = new FormGroup({
    condition: new FormControl(),
  });
  styleForm: FormGroup = new FormGroup({
    style: new FormControl(),
  });
  colorForm: FormGroup = new FormGroup({
    color: new FormControl(),
  });
  minPriceForm: FormGroup = new FormGroup({
    minPriceControl: new FormControl(),
  });

  maxPriceForm: FormGroup = new FormGroup({
    maxPriceControl: new FormControl(),
  });

  @Output() filterContract = new EventEmitter<Filter>();

  genderName: string = '';
  brandName: string = '';
  colorName: string = '';
  conditionName: string = '';
  styleName: string = '';
  minPrice: number = 0;
  maxPrice: number = 100000;

  constructor(
    private brandService: BrandService,
    private styleService: StyleService,
    private colorService: ColorService,
    private conditionService: ConditionService,
    private genderService: GenderService
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
    this.filterContract.emit(new Filter('', '', '', 0, 100000, '', '', '', ''));
  }

  brandSetView() {
    if (this.brandView) {
      this.brandView = false;
      this.genderView = false;
      this.conditionView = false;
      this.styleView = false;
      this.colorView = false;
    } else {
      this.brandView = true;
      this.genderView = false;
      this.conditionView = false;
      this.styleView = false;
      this.colorView = false;
    }
  }

  genderSetView() {
    if (this.genderView) {
      this.brandView = false;
      this.genderView = false;
      this.conditionView = false;
      this.styleView = false;
      this.colorView = false;
    } else {
      this.brandView = false;
      this.genderView = true;
      this.conditionView = false;
      this.styleView = false;
      this.colorView = false;
    }
  }

  styleSetView() {
    if (this.styleView) {
      this.brandView = false;
      this.genderView = false;
      this.conditionView = false;
      this.styleView = false;
      this.colorView = false;
    } else {
      this.brandView = false;
      this.genderView = false;
      this.conditionView = false;
      this.styleView = true;
      this.colorView = false;
    }
  }

  colorSetView() {
    if (this.colorView) {
      this.brandView = false;
      this.genderView = false;
      this.conditionView = false;
      this.styleView = false;
      this.colorView = false;
    } else {
      this.brandView = false;
      this.genderView = false;
      this.conditionView = false;
      this.styleView = false;
      this.colorView = true;
    }
  }

  conditionSetView() {
    if (this.conditionView) {
      this.brandView = false;
      this.genderView = false;
      this.conditionView = false;
      this.styleView = false;
      this.colorView = false;
    } else {
      this.brandView = false;
      this.genderView = false;
      this.conditionView = true;
      this.styleView = false;
      this.colorView = false;
    }
  }

  applyFilter() {
    this.genderName = this.genderForm.value.gender;
    this.brandName = this.brandForm.value.brand;
    this.conditionName = this.conditionForm.value.condition;
    this.colorName = this.colorForm.value.color;
    this.styleName = this.styleForm.value.style;
    this.minPrice = this.minPriceForm.value.minPriceControl;
    this.maxPrice = this.maxPriceForm.value.maxPriceControl;
    if (this.genderName == null) this.genderName = '';
    if (this.brandName == null) this.brandName = '';
    if (this.conditionName == null) this.conditionName = '';
    if (this.colorName == null) this.colorName = '';
    if (this.styleName == null) this.styleName = '';
    if (this.minPrice == null) this.minPrice = 0;
    if (this.maxPrice == null) this.maxPrice = 100000;
    this.filterContract.emit(
      new Filter(
        this.genderName,
        this.brandName,
        this.styleName,
        this.minPrice,
        this.maxPrice,
        this.conditionName,
        this.colorName,
        '',
        ''
      )
    );
  }

  resetFilter() {
    this.filterContract.emit(new Filter('', '', '', 0, 100000, '', '', '', ''));
  }
}
