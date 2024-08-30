import { Component } from '@angular/core';
import { NgForOf, UpperCasePipe, CurrencyPipe } from '@angular/common';
import { ProductsService } from '../products.service';

@Component({
  selector: 'app-product-item',
  standalone: true,
  imports: [NgForOf, UpperCasePipe, CurrencyPipe],
  templateUrl: './product-item.component.html',
  styleUrl: './product-item.component.css'
})
export class ProductItemComponent {
  products: any[];

  constructor(private productsService: ProductsService) {
    this.products = this.productsService.getProducts();
  }
}
