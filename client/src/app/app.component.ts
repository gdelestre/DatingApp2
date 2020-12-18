import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'The Dating App';
  users: any;
  private baseUrl: string = "https://localhost:5001/api"

  constructor(private http: HttpClient) {

  }
  ngOnInit(): void {
    this.getUsers();
  }

  getUsers() {
    this.http.get(this.baseUrl + "/users").subscribe(data => {
      this.users = data;
    },
      err => {
        console.log(err);
      });
  }
}
