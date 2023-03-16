import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { ApiPaths } from '../enums/api-paths';
import { Product } from '../model/Product';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  constructor(private http: HttpClient) {
    console.log('test ', this.getAllProducts());
  }

  baseUrl = environment.baseUrl;

  getAllProducts(): Observable<Product[]> {
    const url = `${this.baseUrl}/${ApiPaths.Products}`;
    return this.http.get<Product[]>(url);
  }
}
