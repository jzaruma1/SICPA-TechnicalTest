import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EnterpriseDetailComponent } from './enterprise-detail/enterprise-detail.component';
import { EnterpriseListComponent } from './enterprise-list/enterprise-list.component';

const routes: Routes = [
  {
    path: "",
    component: EnterpriseListComponent
  },
  {
    path: "new",
    component: EnterpriseDetailComponent
  },
  {
    path: "edit/:id",
    component: EnterpriseDetailComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EnterpriseRoutingModule { }
