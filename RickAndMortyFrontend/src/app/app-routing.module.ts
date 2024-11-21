import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CharacterListComponent } from './components/character-list/character-list.component';
import { EpisodeListComponent } from './components/episode-list/episode-list.component';

const routes: Routes = [
  { path: 'characters', component: CharacterListComponent },
  { path: 'episodes', component: EpisodeListComponent }, // New route for episodes
  { path: '', redirectTo: '/episodes', pathMatch: 'full' },
  { path: '**', redirectTo: '/episodes' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
