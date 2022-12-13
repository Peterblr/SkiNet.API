
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IPagination } from './shared/models/pagination';
import { IProduct } from './shared/models/product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit {
  title = 'Skinet';
  baseUrl = 'https://localhost:7064/api/products?pageSize=50';
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
