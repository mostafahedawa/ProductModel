import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './Material-module';
import { NavComponent } from './nav/nav.component';
import { ProductService } from './Services/product.service';
import { ProductComponent } from './product/product.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { ProductFormComponent } from './product-form/product-form.component';
@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    ProductComponent,
    ProductFormComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule 
  ],
  providers: [ProductService],
  bootstrap: [AppComponent]
})
export class AppModule { }
