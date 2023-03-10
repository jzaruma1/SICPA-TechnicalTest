import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { from, of } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { DepartmentService } from 'src/app/shared/services/department.service';

@Component({
  selector: 'app-department-list',
  templateUrl: './department-list.component.html'
})
export class DepartmentListComponent implements OnInit {

  displayedColumns: string[] = ['name', 'description', 'phone', 'enterpriseName', 'employees', 'status', 'option'];
  dataSource = [];
  records = 10;
  @ViewChild(MatPaginator, { static: true })
  paginator!: MatPaginator;

  constructor(private departmentService: DepartmentService) { }

  ngOnInit(): void {
    this.loadItems();
    from(this.paginator.page)
      .pipe(
        switchMap(() => {
          this.loadItems(this.paginator.pageSize, this.paginator.pageIndex + 1);
          return of(null);
        }),
      )
      .subscribe();
  }

  loadItems(size: number = 10, page: number = 1) {
    this.departmentService.getAll(size, page).subscribe((response: any) => {
      if (response && response.result && response.result.results) {
        this.dataSource = response.result.results;
        this.records = response.result.rowCount;
      }
    });
  }

  getTooltipCount(element: any) {
    return (element.employeeNames as string).length ? (element.employeeNames as string).split(",")?.length : 0;
  }

  getTooltip(element: any) {
    return (element.employeeNames as string).length ? (element.employeeNames as string).split(",").join(" - ") : "";
  }
}
