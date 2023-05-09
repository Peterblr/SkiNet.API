import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { ProductItemComponent } from './product-item/product-item.component';
import { SharedModule } from '../shared/shared.module';
import { ProductDatailsComponent } from './product-datails/product-datails.component';



@NgModule({
  declarations: [
    ShopComponent,
    ProductItemComponent,
    ProductDatailsComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports: [ShopComponent]
})
export class ShopModule { }
