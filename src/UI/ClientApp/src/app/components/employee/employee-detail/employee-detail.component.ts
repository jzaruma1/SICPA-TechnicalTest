import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { DepartmentService } from 'src/app/shared/services/department.service';
import { EmployeeService } from 'src/app/shared/services/employee.service';

@Component({
  selector: 'app-employee-detail',
  templateUrl: './employee-detail.component.html'
})
export class EmployeeDetailComponent implements OnInit {
  entity: any;
  entityId: any;
  form!: FormGroup;
  departments!: any[];
  constructor(private employeeService: EmployeeService,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private router: Router,
    private snackBar: MatSnackBar,
    private departmentService: DepartmentService) { }

  ngOnInit(): void {
    this.initForm();
    this.initData();
    this.entityId = this.route.snapshot.paramMap.get('id');
    if (this.entityId)
      this.loadRecord();
  }

  loadRecord() {
    this.employeeService.get(this.entityId).subscribe((response: any) => {
      if (response.result) {
        this.entity = response.result;
        this.form.patchValue(this.entity, { emitEvent: false });
      }
    });
  }

  initData() {
    this.departmentService.getAll(1000, 1).subscribe((response: any) => {
      if (response && response.result && response.result.results) {
        this.departments = response.result.results;
      }
    });
  }

  initForm() {
    this.form = this.fb.group({
      id: [0],
      name: ["", Validators.required],
      surname: ["", Validators.required],
      email: ["", Validators.required],
      position: ["", Validators.required],
      age: ["", Validators.required],
      status: [true, Validators.required],
      departments: new FormControl('', Validators.required),
      createdBy: [""],
      modifiedBy: [""],
      departmentNames: [""]
    });
  }

  save() {
    if (!this.form.valid) {
      this.snackBar.open(`Complete the required fields.`, 'Ok');
      return;
    }
    const request = this.entityId ? this.employeeService.update(this.form.getRawValue(), this.entityId) : this.employeeService.add(this.form.getRawValue());
    request.subscribe(response => {
      if (response) {
        this.snackBar.open(`Employee ${this.entityId ? 'updated' : 'saved'}!!`, 'Ok');
        this.router.navigateByUrl("/employees");
      }
    });
  }

}
