import { Watch } from './watch.model';

export class Cart {
  public cartId: string;
  public quantity: number = 3;
  public totalPrice: number = 0;
  public userId: string;
  public watchId: string;

  constructor(
    cartId: string,
    quantity: number,
    totalPrice: number,
    watchId: string,
    userId: string
  ) {
    this.cartId = cartId;
    this.quantity = quantity;
    this.totalPrice = totalPrice;
    this.watchId = watchId;
    this.userId = userId;
  }
}
