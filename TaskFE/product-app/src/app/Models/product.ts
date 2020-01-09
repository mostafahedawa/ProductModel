import { Vendor } from './vendor';
import { DietaryFlags } from './dietary-flags';

export interface Product {
    ID:number,
    VendorID:number,
    Vendor:Vendor,
    Title:string,
    Description:string,
    Price:number,
    PhotoName:string,
    DietaryID:number,
    DietaryFlag:DietaryFlags,
    NumberOfViews:number,
    Photo:any
}
