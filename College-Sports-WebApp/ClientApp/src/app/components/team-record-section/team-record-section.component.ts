import { Component, Input, computed, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Competitor } from 'src/api/models';

@Component({
  selector: 'app-team-record-section',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './team-record-section.component.html',
  styleUrl: './team-record-section.component.css'
})
export class TeamRecordSectionComponent {

  protected competitor = signal<Competitor | null>(null);
  @Input('competitor') set _competitor(value: Competitor) {
    this.competitor.set(value);
  };

  protected overallRecordText = computed(() => {
    const competitor = this.competitor();
    if (!competitor) {
      return '';
    }

    const overallRecordEntry = competitor.records?.find(record => record.name === 'overall');

    const overallRecordSummary = overallRecordEntry?.summary ?? '0-0';

    return `(${overallRecordSummary})`;
  });
}
