import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { Filter } from '../shared/models/filter.model';
import { Watch } from '../shared/models/watch.model';
import { WatchService } from '../shared/services/watch.service';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css'],
})
export class HomepageComponent implements OnInit {
  @Input() images: string[] = [
    'https://cdn.shopify.com/s/files/1/0063/5165/0905/files/Tissot_Watches_A_Better_Investment_on_a_Watch._1.png?v=1632813025',
    'https://i.pinimg.com/originals/d0/e7/31/d0e7310d4f8230dc4e974e964cf26d2a.jpg',

    'https://i.ytimg.com/vi/jJH59sQVjd0/maxresdefault.jpg',
  ];
  @Input() filterCategory: EventEmitter<Filter>;
  @Output() filterContract: EventEmitter<Filter>;
  constructor(private watchService: WatchService, private router: Router) {}

  ngOnInit(): void {}

  getWatches(filter: Filter) {
    this.filterCategory.emit();
  }

  navigateToShopTissot() {
    this.router.navigateByUrl('/products');
  }

  navigateToShopFossil() {
    this.router.navigateByUrl('/products');
  }

  navigateToShopCasio() {
    this.router.navigateByUrl('/products');
  }
}
