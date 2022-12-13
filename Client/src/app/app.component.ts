
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IPagination } from './models/pagination';
import { IProduct } from './models/product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit {
  title = 'Skinet';
  baseUrl = 'https://localhost:7064/api/products';
  products: IProduct[];

  constructor(private http: HttpClient) {}
  
  ngOnInit(): void {
    this.http.get(this.baseUrl).subscribe((res: IPagination) => {
      this.products = res.data;
    }, error => {
      console.log(error);
    });
  }  
}
