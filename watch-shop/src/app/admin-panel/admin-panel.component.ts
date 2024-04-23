import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Watch } from '../shared/models/watch.model';
import { WatchService } from '../shared/services/watch.service';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.css'],
})
export class AdminPanelComponent implements OnInit {
  watches: Watch[] = [];
  page: number = 1;
  totalSize: number;

  constructor(private watchService: WatchService, private router: Router) {}

  ngOnInit(): void {
    this.watchService.getWatches().subscribe((response: Watch[]) => {
      this.watches = response;
    });
  }

  delete(watch: Watch) {
    this.watchService.deleteWatch(watch);
  }

  add() {
    this.router.navigateByUrl('/addProduct');
  }
}
