import { Component, OnInit } from '@angular/core';
import { TeamService } from '../team/services/team.service';
import { TeamMember } from '../team/models/team-member';
import { Gelato } from '../gelato/models/gelato';
import { GelatoService } from '../gelato/services/gelato.service';

@Component({
  selector: 'diarioapp-conodelgiorno',
  templateUrl: './conodelgiorno.component.html',
  styleUrls: ['./conodelgiorno.component.css']
})
export class ConodelgiornoComponent implements OnInit {

  team: TeamMember[] = [];
  gelatos: Gelato[] = [];
  weightConoDelGiorno: number | undefined;
  
  constructor(private _teamService: TeamService,
    _gelatoService: GelatoService) { 
    this.team = _teamService.getTeam();
    _gelatoService.getGelatos().subscribe(gelatos => this.gelatos = gelatos);
  }

  ngOnInit(): void {
  }

  // get weigth from scale: auto saves? or use register button?
  gotWeightFromScale(weight: number){
    this.weightConoDelGiorno = weight;
  }

}
