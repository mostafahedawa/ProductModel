import { Component, OnInit, ViewChild } from '@angular/core';
import { ProductService } from '../Services/product.service';
import { Product } from '../Models/product';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Router } from '@angular/router';
@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {

  myImgUrl:string='src/assets/images/noImage.jpg';
  public displayedColumns = ['id', 'title', 'description', 'vendor', 'price', 'dietaryFlag','photoName'];

  public dataSource = new MatTableDataSource<Product>();
  

  constructor(private _productService:ProductService,private _router:Router) { }
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;

  ngOnInit() {
    this.getAllProducts();
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
  getAllProducts= () => {
    this._productService.Get()
    .subscribe(res => {
      this.dataSource.data = res as Product[];
    })
  }
  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  newComponent() {
    this._router.navigate(['product', ""], { replaceUrl: false });
  }

}
