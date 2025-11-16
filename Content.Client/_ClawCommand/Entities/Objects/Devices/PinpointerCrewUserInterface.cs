
using Content.Shared.Localizations;
using JetBrains.Annotations;
using Robust.Client.UserInterface;
using Content.Client._ClawCommand.Entities.UI;
using Content.Shared._ClawCommand.Devices.Components;

namespace Content.Client._ClawCommand.Devices.UI
{
    /// <summary>
    /// Initializes a <see cref="GasFilterWindow"/> and updates it when new server messages are received.
    /// </summary>
    [UsedImplicitly]
    public sealed class PinpointerCrewBoundUserInterface : BoundUserInterface
    {

        [ViewVariables]
        private PinpointerCrewWindow? _window;
        [Dependency] private readonly EntityManager _entManager = default!;

        public PinpointerCrewBoundUserInterface(EntityUid owner, Enum uiKey) : base(owner, uiKey)
        {
        }

        protected override void Open()
        {
            base.Open();
            _window = this.CreateWindow<PinpointerCrewWindow>();

            _window.SelectCrewPressed += OnSelectCrewPressed;
        }

        private void OnSelectCrewPressed()
        {
            if (_window is null) return;
            if (_window.SelectedCrew is null)
            {
                SendMessage(new CrewTrackerSelectCrewMessage(null));
            }
            else
            {
                SendMessage(new CrewTrackerSelectCrewMessage(_window.SelectedCrew));
            }
        }

        /// <summary>
        /// Update the UI state based on server-sent info
        /// </summary>
        /// <param name="state"></param>
        protected override void UpdateState(BoundUserInterfaceState state)
        {
            base.UpdateState(state);
            if (_window == null || state is not PinpointerCrewBoundUserInterfaceState cast)
                return;

            _window.Title = ("Crew tracker");
            if (cast.SelectedCrew is not null)
            {
                _window.SetSelectedCrew(cast.SelectedCrew.ID, cast.SelectedCrew.Name);
            }
            else
            {
                _window.SetSelectedCrew(null, Loc.GetString("comp-pinpointer-crew-select-none"));
            }
            _window.PopulateCrewListUIXML(cast.List);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposing) return;
            _window?.Dispose();
        }
    }
}
