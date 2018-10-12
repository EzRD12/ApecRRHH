import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'dashboard-cmp',
  templateUrl: 'dashboard.component.html',
  styleUrls: ['dashboard.component.css']
})

export class DashboardComponent implements OnInit {

  dataSet: any[] = [];
  ngOnInit() {
    this.dataSet = [{ name: 'Jose', age: 18, address: 'Santo Domingo' }];
  }
}
