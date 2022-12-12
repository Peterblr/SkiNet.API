import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Skinet';
  baseUrl = 'https://localhost:7064/api/products';

  constructor(private http: HttpClient) {}
  
  ngOnInit(): void {
    this.http.get(this.baseUrl).subscribe((res: any) => {
      console.log(res);
    }, error => {
      console.log(error);
    });
  }  
}
