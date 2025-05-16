import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'diarioapp-bilanciadiagnostic',
  templateUrl: './bilanciadiagnostic.component.html',
  styleUrls: ['./bilanciadiagnostic.component.css']
})
export class BilanciadiagnosticComponent implements OnInit {

  weightsFromScale: number[] = [];

  constructor() { }

  ngOnInit(): void {
  }
  
  gotWeightFromScale(weight: number){
    this.weightsFromScale.push(weight);
  }
}
