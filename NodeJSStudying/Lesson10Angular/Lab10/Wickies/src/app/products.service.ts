import { Injectable } from '@angular/core';
import { PRODUCTS } from './mock-products';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor() { }

  getProducts() {
    return PRODUCTS;
  }
}
