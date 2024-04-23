import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { ItemCardComponent } from './item-card/item-card.component';
import { ItemListComponent } from './item-list/item-list.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { LoginComponent } from './login/login.component';
import { HomepageComponent } from './homepage/homepage.component';
import { NgbModule, NgbTooltip } from '@ng-bootstrap/ng-bootstrap';
import { Routes, RouterModule } from '@angular/router';
import { FilterListComponent } from './filter-list/filter-list.component';
import { CartComponent } from './cart/cart.component';
import { PurchaseHistoryComponent } from './purchase-history/purchase-history.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxPaginationModule } from 'ngx-pagination';
import { CheckoutComponent } from './checkout/checkout.component';
import { AddProductComponent } from './add-product/add-product.component';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';
import { EditProductComponent } from './edit-product/edit-product.component';
import { WishListComponent } from './wish-list/wish-list.component';

const appRoutes: Routes = [
  { path: '', component: HomepageComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: LoginComponent },
  { path: 'products', component: ItemListComponent },
  { path: 'products/productDetails/:id', component: ProductDetailsComponent },
  { path: 'cart', component: CartComponent },
  { path: 'checkout', component: CheckoutComponent },
  { path: 'purchase/history', component: PurchaseHistoryComponent },
  { path: 'addProduct', component: AddProductComponent },
  { path: 'adminPanel', component: AdminPanelComponent },
  { path: 'editProduct/:id', component: EditProductComponent },
  { path: 'wishList', component: WishListComponent },
];

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    ItemCardComponent,
    ItemListComponent,
    ProductDetailsComponent,
    LoginComponent,
    HomepageComponent,
    FilterListComponent,
    CartComponent,
    PurchaseHistoryComponent,
    CheckoutComponent,
    AddProductComponent,
    AdminPanelComponent,
    EditProductComponent,
    WishListComponent,
  ],
  imports: [
    BrowserModule,
    NgbModule,
    RouterModule.forRoot(appRoutes),
    HttpClientModule,
    ReactiveFormsModule,
    NgxPaginationModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
