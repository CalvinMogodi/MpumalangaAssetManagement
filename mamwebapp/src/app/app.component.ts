import { Component } from '@angular/core';
import { Router } from '@angular/router';
//import { PrimeNGConfig } from 'primeng/api';
import { AuthenticationService } from '../app/services/authentication.service';
import { User } from '../app/models/user.model';
import { Role } from '../app/models/role.model';
import { OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  currentUser: User;
  loggedIn: boolean = false;

  constructor(//private primengConfig: PrimeNGConfig,
    private router: Router,
    private authenticationService: AuthenticationService
  ) {
    this.authenticationService.currentUser.pipe().subscribe(x => {
      this.currentUser = x;
      this.loggedIn = this.currentUser == null ? false : true;
      if(this.currentUser != null)  {
        this.loggedIn = this.currentUser.id == 0 ? false : true;
      }
      if(!this.loggedIn){       
        this.router.navigate(['login']);
      }
        
    }
    );
  }

  ngOnInit() {
   // this.authenticationService.logout();
    //this.router.navigate(['/login']);
    //this.primengConfig.ripple = true;
}

  logout() {
    this.authenticationService.logout();
    this.router.navigate(['/login']);
  }

  isAdmin() {
    if(this.currentUser.role != null)
      return this.currentUser && (this.currentUser.role.id === 2 || this.currentUser.role.id === 4);
    else
      return false;
  }

  isDepartmantUser() {
    if(this.currentUser.role != null)
      return this.currentUser && (this.currentUser.role.id === 7);
    else
      return false;
  }
}
