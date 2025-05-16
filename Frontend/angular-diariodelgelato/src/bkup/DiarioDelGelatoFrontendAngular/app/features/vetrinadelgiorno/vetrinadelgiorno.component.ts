import { Component, OnInit } from '@angular/core';
import { Gelato } from '../gelato/models/gelato';
import { GelatoService } from '../gelato/services/gelato.service';

@Component({
  selector: 'diarioapp-vetrinadelgiorno',
  templateUrl: './vetrinadelgiorno.component.html',
  styleUrls: ['./vetrinadelgiorno.component.css']
})
export class VetrinadelgiornoComponent implements OnInit {

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
