import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

import { BilanciaService } from './services/bilancia.service';
import { BilanciaResponse } from './models/bilancia-response';

enum ScaleStatus {
  Fault = 1,
  StableAtZero = 2,
  InMotion = 3,
  Stable = 4,
  UnderZero = 5,
  OverWeight = 6,
  RequiresCalibration = 7,
  RequiresReZeroing = 8
};

@Component({
  selector: 'diarioapp-bilancia',
  templateUrl: './bilancia.component.html',
  styleUrls: ['./bilancia.component.css']
})
export class BilanciaComponent implements OnInit {

  @Output() weightRead = new EventEmitter<number>();

  statusMessage: string | undefined;
  weightFromScale: number = 0;

  constructor(private _serviceBilancia: BilanciaService, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  getWeightFromScale(){
    this.statusMessage = undefined;
    this._serviceBilancia.getWeight().subscribe(
      response => this.processBilanciaResponse(response),
      error => this.statusMessage = error.message,
      )
  }

  processBilanciaResponse(response: BilanciaResponse){
    this.statusMessage = "";
    if (response.success) {
      // the scale always return zero in oz
      this.weightFromScale = response.weight;
      if (response.weight !=0 && !response.readingInGrams) {
        this.statusMessage = "Verifique a unidade de peso da balança. Pressione a tecla [kg/lb] na balança para selecionar gramas. A letra 'g' irá aparecer no canto superior direito do display.";
        this.weightFromScale = -1; //if weight scale was not in grams discard the reading
      } else {
        // raise event passing weight read from scale
        this.onWeightRead(response.weight);
      }
    } else {
      this.weightFromScale = 0;
      this.statusMessage = response.message;
      if (!response.connected) { 
        switch (response.errorCode) {
          case ScaleStatus.Fault: 
            this.statusMessage = "Balança desconectada! Verifique que esteja conectada a USB e ligada - tecla mais a esquerda da balança.";
            break;
          case ScaleStatus.UnderZero:
            this.statusMessage = "Peso negativo! Pressione a tecla [0.0 TARE] para zerar a balança antes de pesar.";
            break;
          case ScaleStatus.OverWeight:
            this.statusMessage = "Excesso de peso! A Dymo 25 tem capacidade para pesar até de 12kg.";
            break;
        }
      }
    }
  }

  onWeightRead(weight: number){
    this.weightRead.emit(weight);
  }
}
