import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { Brand } from '../shared/models/brand.model';
import { Color } from '../shared/models/color.model';
import { Condition } from '../shared/models/condition.model';
import { Gender } from '../shared/models/gender.model';
import { Watch } from '../shared/models/watch.model';
import { BrandService } from '../shared/services/brand.service';
import { ColorService } from '../shared/services/color.service';
import { ConditionService } from '../shared/services/condition.service';
import { GenderService } from '../shared/services/gender.service';
import { WatchService } from '../shared/services/watch.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css'],
})
export class AddProductComponent implements OnInit {
  constructor(
    private brandService: BrandService,
    private colorService: ColorService,
    private conditionService: ConditionService,
    private genderService: GenderService,
    private watchService: WatchService,
    private router: Router
  ) {}

  brands: Brand[];
  colors: Color[];
  conditions: Condition[];
  genders: Gender[];

  //forms
  brand: string;
  color: string;
  model: string;
  braceletMaterial: string;
  genderMan: boolean;
  genderWoman: boolean;
  genderUnisex: boolean;
  conditionNew: boolean;
  conditionUsed: boolean;
  imagePath: string;
  caseDiameter: number;
  waterResistant: number;
  datePublished: Date;
  price: number;
  shippingPrice: number;
  guarantee: number;
  available: number;

  ngOnInit(): void {
    this.brandService.getBrands().subscribe((response: Brand[]) => {
      this.brands = response;
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
  }

  addWatch() {
    this.brandService.getBrandByName(this.brand).subscribe((res1) => {
      let brandObject = res1;

      this.colorService.getColorByName(this.color).subscribe((res2) => {
        let colorObject = res2;

        if (this.conditionNew) {
          this.conditionService.getConditionByName('New').subscribe((res3) => {
            let condition = res3;

            if (this.genderMan) {
              this.genderService.getGenderByName('Man').subscribe((res4) => {
                let gender = res4;

                let watch = new Watch(
                  '',
                  this.model,
                  this.datePublished,
                  this.braceletMaterial,
                  this.caseDiameter,
                  this.waterResistant,
                  this.price,
                  this.shippingPrice,
                  this.guarantee,
                  this.imagePath,
                  this.available,
                  brandObject,
                  colorObject,
                  condition,
                  gender
                );

                this.watchService.addWatch(watch);
              });
            } else if (this.genderWoman) {
              this.genderService.getGenderByName('Woman').subscribe((res4) => {
                let gender = res4;

                let watch = new Watch(
                  '',
                  this.model,
                  this.datePublished,
                  this.braceletMaterial,
                  this.caseDiameter,
                  this.waterResistant,
                  this.price,
                  this.shippingPrice,
                  this.guarantee,
                  this.imagePath,
                  this.available,
                  brandObject,
                  colorObject,
                  condition,
                  gender
                );

                this.watchService.addWatch(watch);
              });
            } else if (this.genderUnisex) {
              this.genderService.getGenderByName('Unisex').subscribe((res4) => {
                let gender = res4;

                let watch = new Watch(
                  '',
                  this.model,
                  this.datePublished,
                  this.braceletMaterial,
                  this.caseDiameter,
                  this.waterResistant,
                  this.price,
                  this.shippingPrice,
                  this.guarantee,
                  this.imagePath,
                  this.available,
                  brandObject,
                  colorObject,
                  condition,
                  gender
                );

                this.watchService.addWatch(watch);
              });
            }
          });
        } else {
          this.conditionService.getConditionByName('Used').subscribe((res5) => {
            let condition = res5;

            if (this.genderMan) {
              this.genderService.getGenderByName('Man').subscribe((res5) => {
                let gender = res5;

                let watch = new Watch(
                  '',
                  this.model,
                  this.datePublished,
                  this.braceletMaterial,
                  this.caseDiameter,
                  this.waterResistant,
                  this.price,
                  this.shippingPrice,
                  this.guarantee,
                  this.imagePath,
                  this.available,
                  brandObject,
                  colorObject,
                  condition,
                  gender
                );

                this.watchService.addWatch(watch);
              });
            } else if (this.genderWoman) {
              this.genderService.getGenderByName('Woman').subscribe((res) => {
                let gender = res;

                let watch = new Watch(
                  '',
                  this.model,
                  this.datePublished,
                  this.braceletMaterial,
                  this.caseDiameter,
                  this.waterResistant,
                  this.price,
                  this.shippingPrice,
                  this.guarantee,
                  this.imagePath,
                  this.available,
                  brandObject,
                  colorObject,
                  condition,
                  gender
                );

                this.watchService.addWatch(watch);
              });
            } else if (this.genderUnisex) {
              this.genderService.getGenderByName('Unisex').subscribe((res) => {
                let gender = res;

                let watch = new Watch(
                  '',
                  this.model,
                  this.datePublished,
                  this.braceletMaterial,
                  this.caseDiameter,
                  this.waterResistant,
                  this.price,
                  this.shippingPrice,
                  this.guarantee,
                  this.imagePath,
                  this.available,
                  brandObject,
                  colorObject,
                  condition,
                  gender
                );

                this.watchService.addWatch(watch);
              });
            }
          });
        }
      });
    });
  }

  cancel() {
    Swal.fire({
      title: 'Are you sure to cancel?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonText: 'No',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, cancel!',
    }).then((result) => {
      if (result.isConfirmed) {
        this.router.navigateByUrl('/adminPanel');
      }
    });
  }
}
