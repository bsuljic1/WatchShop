export class WishList {
  public wishListId: string;
  public watchId: string;
  public userId: string;

  constructor(wishListId: string, watchId: string, userId: string) {
    this.wishListId = wishListId;
    this.watchId = watchId;
    this.userId = userId;
  }
}
