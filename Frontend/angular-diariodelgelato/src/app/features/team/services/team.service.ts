// CRUD service for team-member management
import { Injectable } from '@angular/core';
import { TeamMember } from '../models/team-member';

@Injectable({
  providedIn: 'root'
})
export class TeamService {

  team: TeamMember[] = [{fullName:"Rafael Nadal"}, {fullName:"Roger Federer"}, {fullName:"Guga Kuerten"}];
  
  constructor() { }

  getTeam(){
    return this.team;
  }
}
