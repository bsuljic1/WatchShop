export class Purchase {
  public purchaseId: string;
  public purchasePrice: number;
  public quantity: number;
  public timeOfPurchase: Date;
  public userId: string;
  public watchId: string;

  constructor(
    purchaseId: string,
    purchasePrice: number,
    quantity: number,
    timeOfPurchase: Date,
    userId: string,
    watchId: string
  ) {
    this.purchaseId = purchaseId;
    this.purchasePrice = purchasePrice;
    this.quantity = quantity;
    this.timeOfPurchase = timeOfPurchase;
    this.userId = userId;
    this.watchId = watchId;
  }
}
