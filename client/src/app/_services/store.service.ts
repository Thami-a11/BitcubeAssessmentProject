import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Item } from '../models/ItemSummary';
import { Price } from '../models/price';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class StoreService {

  BaseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  AddToInventory(item: any) {
    return this.http.post(this.BaseUrl + 'OnlineStore/AddToInventory', item);
  }
  AddToPrice(item: any) {
    return this.http.post<Price[]>(this.BaseUrl + 'OnlineStore/AddPrice', item);
  }

  SummaryOfAll() {
    return this.http.get<Product>(this.BaseUrl + 'OnlineStore/GetSummary');
  }

  SellProducts(item: any) {
    return this.http.post(this.BaseUrl + 'OnlineStore/SellItem', item);
  }

  SummaryOfItem(ProductType: any) {
    return this.http.post<Item>(this.BaseUrl + 'OnlineStore/GetItemSummary', ProductType);
  }

}
