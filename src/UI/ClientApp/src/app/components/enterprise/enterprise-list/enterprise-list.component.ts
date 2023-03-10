import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { from, of } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { EnterpriseService } from 'src/app/shared/services/enterprise.service';

@Component({
  selector: 'app-enterprise-list',
  templateUrl: './enterprise-list.component.html'
})
export class EnterpriseListComponent implements OnInit {

  displayedColumns: string[] = ['name', 'address', 'phone', 'departments', 'status', 'option'];
  dataSource = [];
  records = 10;
  @ViewChild(MatPaginator, { static: true })
  paginator!: MatPaginator;

  constructor(private enterpriseService: EnterpriseService) { }

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
    this.enterpriseService.getAll(size, page).subscribe((response: any) => {
      if (response && response.result && response.result.results) {
        this.dataSource = response.result.results;
        this.records = response.result.rowCount;
      }
    });
  }

  getTooltipCount(element: any) {
    return (element.departmentNames as string).length ? (element.departmentNames as string).split(",")?.length : 0;
  }

  getTooltip(element: any) {
    return (element.departmentNames as string).length ? (element.departmentNames as string).split(",").join(" - ") : "";
  }
}
