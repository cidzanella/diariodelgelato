import { Component, OnInit } from '@angular/core';
import { GelatoService } from './services/gelato.service';
import { Gelato } from './models/gelato';

@Component({
  selector: 'diarioapp-gelato',
  templateUrl: './gelato.component.html',
  styleUrls: ['./gelato.component.css']
})
export class GelatoComponent implements OnInit {

  gelatos: Gelato[] = [];
  
  constructor(private gelatoService: GelatoService) { }

  ngOnInit(): void {
    this.getGelatos();
  }

  getGelatos() {
    this.gelatoService.getGelatos().subscribe(gelatos => {
      this.gelatos = gelatos;
    });
  }
}
