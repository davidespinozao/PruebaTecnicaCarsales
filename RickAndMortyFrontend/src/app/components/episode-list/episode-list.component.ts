import { Component, OnInit } from '@angular/core';
import { RickAndMortyService } from '../../services/rick-and-morty.service';

@Component({
  selector: 'app-episode-list',
  templateUrl: './episode-list.component.html',
  styleUrls: ['./episode-list.component.css']
})
export class EpisodeListComponent implements OnInit {
  episodes: any[] = [];

  constructor(private rickAndMortyService: RickAndMortyService) { }

  ngOnInit(): void {
    this.rickAndMortyService.getEpisodes().subscribe((data: any) => {
      this.episodes = data.results.map((episode: any) => ({
        ...episode,
        image: this.getRandomCharacterImage(episode.characters),
      }));
    });
  }

  getRandomCharacterImage(characters: string[]): string {
    if (characters.length === 0) {
      return 'https://via.placeholder.com/150'; // Placeholder image if no characters
    }
    const randomIndex = Math.floor(Math.random() * characters.length);
    const characterUrl = characters[randomIndex];
    const characterId = characterUrl.split('/').pop(); // Extract character ID from URL
    return `https://rickandmortyapi.com/api/character/avatar/${characterId}.jpeg`;
  }
}
