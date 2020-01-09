import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Vendor } from '../Models/vendor';
import { environment } from 'src/environments/environment';
import { DietaryFlags } from '../Models/dietary-flags';

@Injectable({
  providedIn: 'root'
})
export class LookupService {

  constructor(private http:HttpClient) { }
  API_CONTROLLER = "Lookups";
  
  GetAllVendors(): Observable<Vendor[]> {
    return this.http.get<Vendor[]>(`${environment.apiUrl}${this.API_CONTROLLER}/GetAllVendors`);
  }
  GetAllFlags(): Observable<DietaryFlags[]> {
    return this.http.get<DietaryFlags[]>(`${environment.apiUrl}${this.API_CONTROLLER}/GetAllFlags`);
  }
}
