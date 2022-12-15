import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { ResponseDataDto } from '../models/ResponseDataDto';

import { BaseService } from './base.service';
import { Product } from '../models/Product';

@Injectable({
  providedIn: 'root'
})

  
export class ProductService  extends BaseService {
  
private _BaseUrl = 'api/product';  

  getProducts(): Observable<ResponseDataDto> {
    return this._httpClient.get<ResponseDataDto>(this._BaseUrl)
      .catch(this.handleError);
  }

  createProduct(product: Product): Observable<ResponseDataDto> {
    return this._httpClient.post<ResponseDataDto>(this._BaseUrl, product)
      .catch(this.handleError);
  }

  updateProduct(product: Product): Observable<ResponseDataDto> {
    return this._httpClient.put<ResponseDataDto>(this._BaseUrl, product)
      .catch(this.handleError);
  }

  deleteProduct(product: Product): Observable<ResponseDataDto> {     
    return this._httpClient.request<ResponseDataDto>('delete', this._BaseUrl, { body: product })
      .catch(this.handleError);    
  }
  
}


