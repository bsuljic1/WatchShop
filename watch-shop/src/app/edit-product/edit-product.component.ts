import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import Swal from 'sweetalert2';
import { textChangeRangeIsUnchanged } from 'typescript';
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
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css'],
})
export class EditProductComponent implements OnInit {
  constructor(
    private brandService: BrandService,
    private colorService: ColorService,
    private conditionService: ConditionService,
    private genderService: GenderService,
    private watchService: WatchService,
    private router: Router,
    private route: ActivatedRoute
  ) {}
  @Input() watch: Watch;
  @Input() id: string;

  brands: Brand[];
  colors: Color[];
  conditions: Condition[];
  genders: Gender[];

  //forms
  brand: string;
  color: string;
  model: string;
  braceletMaterial: string;
  genderMan: boolean = false;
  genderWoman: boolean = false;
  genderUnisex: boolean = false;
  conditionNew: boolean = false;
  conditionUsed: boolean = false;
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

    this.route.params.subscribe((params: Params) => {
      this.id = params['id'];
      this.watchService.getWatchById(this.id).subscribe((response: Watch) => {
        this.watch = response;
        this.brand = this.watch.brand.brandName;
        this.model = this.watch.model;
        this.braceletMaterial = this.watch.braceletMaterial;
        this.caseDiameter = this.watch.caseDiameter;
        this.waterResistant = this.watch.waterResistant;
        this.imagePath = this.watch.imagePath;
        this.price = this.watch.price;
        this.shippingPrice = this.watch.shippingPrice;
        this.guarantee = this.watch.guarantee;
        this.available = this.watch.available;
        this.datePublished = this.watch.datePublished;
        this.color = this.watch.color.colorName;

        if (this.watch.condition.conditionName == 'New')
          this.conditionNew = true;
        else this.conditionUsed = true;

        if (this.watch.gender.genderName == 'Man') this.genderMan = true;
        else if (this.watch.gender.genderName == 'Woman')
          this.genderWoman = true;
        else this.genderUnisex = true;
      });
    });
  }

  editWatch() {
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
                  this.id,
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

                this.watchService.updateWatch(this.id, watch);
              });
            } else if (this.genderWoman) {
              this.genderService.getGenderByName('Woman').subscribe((res4) => {
                let gender = res4;

                let watch = new Watch(
                  this.id,
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

                this.watchService.updateWatch(this.id, watch);
              });
            } else if (this.genderUnisex) {
              this.genderService.getGenderByName('Unisex').subscribe((res4) => {
                let gender = res4;

                let watch = new Watch(
                  this.id,
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

                this.watchService.updateWatch(this.id, watch);
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
                  this.id,
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

                this.watchService.updateWatch(this.id, watch);
              });
            } else if (this.genderWoman) {
              this.genderService.getGenderByName('Woman').subscribe((res) => {
                let gender = res;

                let watch = new Watch(
                  this.id,
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

                this.watchService.updateWatch(this.id, watch);
              });
            } else if (this.genderUnisex) {
              this.genderService.getGenderByName('Unisex').subscribe((res) => {
                let gender = res;

                let watch = new Watch(
                  this.id,
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

                this.watchService.updateWatch(this.id, watch);
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
