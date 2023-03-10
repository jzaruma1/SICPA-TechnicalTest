import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { from } from 'rxjs';
import { take, tap } from 'rxjs/operators';
import { DepartmentService } from 'src/app/shared/services/department.service';
import { EnterpriseService } from 'src/app/shared/services/enterprise.service';

@Component({
  selector: 'app-department-detail',
  templateUrl: './department-detail.component.html'
})
export class DepartmentDetailComponent implements OnInit {

  entity: any;
  entityId: any;
  form!: FormGroup;
  enterprises!: any;
  constructor(private departmentService: DepartmentService,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private router: Router,
    private snackBar: MatSnackBar,
    private enterprise: EnterpriseService) { }

  ngOnInit(): void {
    this.initForm();
    this.initData();
    this.entityId = this.route.snapshot.paramMap.get('id');
    if (this.entityId)
      this.loadRecord();
  }

  loadRecord() {
    this.departmentService.get(this.entityId).subscribe((response: any) => {
      if (response.result) {
        this.entity = response.result;
        this.form.patchValue(this.entity, { emitEvent: false });
      }
    });
  }

  initForm() {
    this.form = this.fb.group({
      id: [0],
      name: ["", Validators.required],
      description: ["", Validators.required],
      phone: ["", Validators.required],
      enterpriseId: [0, Validators.required],
      status: [true, Validators.required],
      createdBy: [""],
      modifiedBy: [""],
      enterpriseName: [""],
      employeeNames: [""]
    });
  }

  initData() {
    this.enterprise.getAll(1000, 1).subscribe((response: any) => {
      if (response && response.result && response.result.results) {
        this.enterprises = response.result.results;
      }
    });
  }

  save() {
    if (!this.form.valid) {
      this.snackBar.open(`Complete the required fields.`, 'Ok');
      return;
    }
    const request = this.entityId ? this.departmentService.update(this.form.getRawValue(), this.entityId) : this.departmentService.add(this.form.getRawValue());
    request.subscribe(
      response => {
        if (response) {
          this.snackBar.open(`Department ${this.entityId ? 'updated' : 'saved'}!!`, 'Ok');
          this.router.navigateByUrl("/departments");
        }
      });
  }
}
