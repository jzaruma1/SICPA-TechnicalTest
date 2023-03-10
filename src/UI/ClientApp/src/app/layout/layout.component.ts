import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss']
})
export class LayoutComponent implements OnInit {

  menuList = [
    {
      title: 'Enterprises',
      iconId: 'business',
      url: '/enterprises',
    },
    {
      title: 'Departments',
      iconId: 'apps',
      url: '/departments',
    },
    {
      title: 'Employees',
      iconId: 'supervised_user_circle',
      url: '/employees',
    }
  ];
  constructor() { }

  ngOnInit(): void {
  }

}
