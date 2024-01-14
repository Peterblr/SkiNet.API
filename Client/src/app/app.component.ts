
import { Component, OnInit } from '@angular/core';
import { BasketService } from './basket/basket.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit {
  title = 'Skinet';

  constructor(private bascketService: BasketService) {}
  
  ngOnInit(): void {
    const basketId = localStorage.getItem('basket_id');
    if (basketId)
    {
      this.bascketService.getBasket(basketId).subscribe(() => {
        console.log('initialised basket');
      }, error => {
        console.log(error)
      })
    }
  }  
}
