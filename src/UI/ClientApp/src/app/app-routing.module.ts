import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './layout/layout.component';

const routes: Routes = [
  {
    path: "",
    component: LayoutComponent,
    children: [
      {
        path: "employees",
        loadChildren: () => import("./components/employee/employee.module").then(x => x.EmployeeModule)
      },
      {
        path: "departments",
        loadChildren: () => import("./components/department/department.module").then(x => x.DepartmentModule)
      },
      {
        path: "enterprises",
        loadChildren: () => import("./components/enterprise/enterprise.module").then(x => x.EnterpriseModule)
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
