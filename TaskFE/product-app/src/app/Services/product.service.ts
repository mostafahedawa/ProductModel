import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from '../Models/product';
import { environment } from 'src/environments/environment';
const httpOptions = {
  headers: new HttpHeaders({
    "Content-Type": "application/json"
  })
};
@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http:HttpClient) { }
  API_CONTROLLER = "Product";
  
  Get(): Observable<Product[]> {
    return this.http.get<Product[]>(`${environment.apiUrl}${this.API_CONTROLLER}`);
  }
  Find(id:number): Observable<any> {
    return this.http.get<any>(`${environment.apiUrl}${this.API_CONTROLLER}/${id}`);
  }
  Add(entity:Product): Observable<Product> {
    debugger;
    return this.http.post<Product>(`${environment.apiUrl}${this.API_CONTROLLER}`, entity,httpOptions);
  }
  Update(Product:Product): Observable<Product> {
    return this.http.put<Product>(`${environment.apiUrl}${this.API_CONTROLLER}`, Product,httpOptions);
  }
  Delete(id:number): Observable<any> {
    return this.http.delete(`${environment.apiUrl}${this.API_CONTROLLER}/${id}`);
  }
}
