import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-leaseregister',
  templateUrl: './leaseregister.component.html',
  styleUrls: ['./leaseregister.component.css']
})
export class LeaseRegisterComponent implements OnInit {
  items: MenuItem[];

  constructor() { }

  ngOnInit() {
    this.items = [{ icon: 'pi pi-home', url: 'dashboard' },
    { label: 'Hiring' }];
  }

}
