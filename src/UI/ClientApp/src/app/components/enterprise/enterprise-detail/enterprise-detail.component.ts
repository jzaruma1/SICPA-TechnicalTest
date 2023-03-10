import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { EnterpriseService } from 'src/app/shared/services/enterprise.service';

@Component({
  selector: 'app-enterprise-detail',
  templateUrl: './enterprise-detail.component.html'
})
export class EnterpriseDetailComponent implements OnInit {

  entity: any;
  entityId: any;
  form!: FormGroup;
  constructor(private enterpriseService: EnterpriseService,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private router: Router,
    private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.initForm();
    this.entityId = this.route.snapshot.paramMap.get('id');
    if (this.entityId)
      this.loadRecord();
  }

  loadRecord() {
    this.enterpriseService.get(this.entityId).subscribe((response: any) => {
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
      address: ["", Validators.required],
      phone: ["", Validators.required],
      status: [true, Validators.required],
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
    const request = this.entityId ? this.enterpriseService.update(this.form.getRawValue(), this.entityId) : this.enterpriseService.add(this.form.getRawValue());
    request.subscribe(response => {
      if (response) {
        this.snackBar.open(`Enterprise ${this.entityId ? 'updated' : 'saved'}!!`, 'Ok');
        this.router.navigateByUrl("/enterprises");
      }
    });
  }

}
