import { Brand } from './brand.model';
import { Color } from './color.model';
import { Condition } from './condition.model';
import { Gender } from './gender.model';

export class Watch {
  public watchId: string;
  public brand: Brand;
  public model: string;
  public imagePath: string;
  public price: number;
  public shippingPrice: number;
  public waterResistant: number;
  public guarantee: number;
  public condition: Condition;
  public color: Color;
  public caseDiameter: number;
  public braceletMaterial: string;
  public gender: Gender;
  public datePublished: Date;
  public available: number;

  constructor(
    watchId: string,
    model: string,
    datePublished: Date,
    braceletMaterial: string,
    caseDiameter: number,
    waterResistant: number,
    price: number,
    shippingPrice: number,
    guarantee: number,
    imagePath: string,
    available: number,
    brand: Brand,
    color: Color,
    condition: Condition,
    gender: Gender
  ) {
    this.watchId = watchId;
    this.brand = brand;
    this.model = model;
    this.imagePath = imagePath;
    this.price = price;
    this.shippingPrice = shippingPrice;
    this.waterResistant = waterResistant;
    this.guarantee = guarantee;
    this.condition = condition;
    this.color = color;
    this.caseDiameter = caseDiameter;
    this.braceletMaterial = braceletMaterial;
    this.datePublished = datePublished;
    this.gender = gender;
    this.available = available;
  }
}
