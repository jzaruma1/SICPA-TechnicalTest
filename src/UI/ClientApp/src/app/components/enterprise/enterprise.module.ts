import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EnterpriseRoutingModule } from './enterprise-routing.module';
import { EnterpriseListComponent } from './enterprise-list/enterprise-list.component';
import { EnterpriseDetailComponent } from './enterprise-detail/enterprise-detail.component';
import { SharedModule } from 'src/app/shared/shared.module';


@NgModule({
  declarations: [
    EnterpriseListComponent,
    EnterpriseDetailComponent
  ],
  imports: [
    CommonModule,
    EnterpriseRoutingModule,
    SharedModule
  ]
})
export class EnterpriseModule { }
