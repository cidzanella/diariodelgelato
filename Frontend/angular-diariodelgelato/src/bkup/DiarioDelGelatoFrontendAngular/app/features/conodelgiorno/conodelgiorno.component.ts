import { Component, OnInit } from '@angular/core';
import { TeamService } from '../team/services/team.service';
import { TeamMember } from '../team/models/team-member';
import { Gelato } from '../gelato/models/gelato';
import { GelatoService } from '../gelato/services/gelato.service';
import { ConodelgiornoService } from './services/conodelgiorno.service';
import { Conodelgiorno } from './models/conodelgiorno';

@Component({
  selector: 'diarioapp-conodelgiorno',
  templateUrl: './conodelgiorno.component.html',
  styleUrls: ['./conodelgiorno.component.css']
})
export class ConodelgiornoComponent implements OnInit {

  team: TeamMember[] = [];
  gelatos: Gelato[] = [];
  conoDelGiorno: Conodelgiorno | undefined;
  weightConoDelGiorno: number | undefined;
  
  constructor(private _teamService: TeamService,
    private _gelatoService: GelatoService,
    private _conodelgiornoService: ConodelgiornoService) { 
    this.team = _teamService.getTeam();
    _gelatoService.getGelatos().subscribe(gelatos => this.gelatos = gelatos);
  }

  ngOnInit(): void {
  }

  // get weigth from scale: auto saves? or use register button?
  gotWeightFromScale(weightIn: number){
    this.conoDelGiorno = <Conodelgiorno>{weight: weightIn};
    // gelatoA
    // gelatoB
    // teamMember
    // timestamp pegar do servidor é mais seguro!
    
    //this.weightConoDelGiorno = weight;
    
    //this._conodelgiornoService.registerConoDelGiorno(this.conoDelGiorno)

  }


}
