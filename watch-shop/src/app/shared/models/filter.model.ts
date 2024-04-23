export class Filter {
  public genderName: string = '';
  public brandName: string = '';
  public styleName: string = '';
  public minPrice: number = 0;
  public maxPrice: number = 100000;
  public conditionName: string = '';
  public colorName: string = '';
  public searchText: string = '';
  public sortBy: string = '';

  constructor(
    genderName: string,
    brandName: string,
    styleName: string,
    minPrice: number,
    maxPrice: number,
    conditionName: string,
    colorName: string,
    searchText: string,
    sortBy: string
  ) {
    this.genderName = genderName;
    this.brandName = brandName;
    this.minPrice = minPrice;
    this.maxPrice = maxPrice;
    this.conditionName = conditionName;
    this.colorName = colorName;
    this.searchText = searchText;
    this.styleName = styleName;
    this.sortBy = sortBy;
  }
}
