import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProductComponent } from './product/product.component';
import { ProductFormComponent } from './product-form/product-form.component';

const routes: Routes = [
  {
    path:"",
    redirectTo:'products',
    pathMatch:'full'
  },
  {
    path:'products',
    component:ProductComponent
  },
  { path: 'product/:productId', component: ProductFormComponent }, 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
