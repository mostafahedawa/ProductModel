import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { ProductService } from '../Services/product.service';
import { Router } from '@angular/router';
import { Product } from '../Models/product';
import { LookupService } from '../Services/lookup.service';
import { DietaryFlags } from '../Models/dietary-flags';
import { Vendor } from '../Models/vendor';

@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.scss']
})
export class ProductFormComponent implements OnInit {
  myForm: FormGroup;
  fileToUpload: File = null;
  imageUrl: string = "assets/img/noImage.jpg/";
  FlagList: DietaryFlags[];
  VendorList: Vendor[];
  constructor(private fb: FormBuilder,
    private _router:Router,
    private _productService:ProductService,
    private _lookupService:LookupService) { }

  ngOnInit() {
    this.getLookups();
    this.myForm = this.fb.group({
      title: ['', Validators.required],
      description: ['', Validators.required],
      price: ['', Validators.required],
      photo: [null],
      photoName:[''],
      VendorID:[],
      DietaryID:[]
    });
  }
  getLookups() {
    this._lookupService.GetAllFlags().subscribe(result=>{
      this.FlagList = result;
    });
    this._lookupService.GetAllVendors().subscribe(result=>{
      this.VendorList = result;
    });
  }

  onSubmit(form: FormGroup) {
      var entityToAdd:Product = {
        Description : this.myForm.get('description').value,
        DietaryID: this.myForm.get('DietaryID').value,
        ID: 0,
        NumberOfViews : 0,
        //Photo:this.fileToUpload,
        Photo:null,
        PhotoName: this.fileToUpload.name,
        Price: this.myForm.get('price').value,
        Title:this.myForm.get('title').value,
        VendorID:this.myForm.get('VendorID').value,
        DietaryFlag:null,
        Vendor:null
      }
     // this.myForm.get('photo').setValue(this.fileToUpload);
      //this.myForm.get('photoName').setValue(this.fileToUpload.name);
     // var formVal = this.myForm.value;
    this._productService.Add(entityToAdd).subscribe(
      result=>{
        debugger;
        if(result != null)
        {
          this._router.navigate(['products', ""], { replaceUrl: false });
        }
      }
    )
    console.log('Valid?', form.valid); // true or false
    console.log('title', form.value.title);
    console.log('description', form.value.description);
    console.log('price', form.value.price);
    console.log('photoName', form.value.photoName);
  }

  onFileSubmit(event) {
    //this.myForm.get('photoName').setValue(event.target.files[0]);
    console.log(event);
  }

  handleFileInput(files: FileList) {
    debugger;
    this.fileToUpload = files.item(0);
    var reader = new FileReader();
    reader.onload = (event:any)=>{
      debugger;
      this.imageUrl = event.target.result;
      //this.myForm.get('photoName').setValue(event.target.result);   
     }
     reader.readAsDataURL(this.fileToUpload);
     
  }

}
