//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="RespondFlowItemViewModel.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   RespondFlowItemViewModel.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.ViewModels
{
    using Prism.Mvvm;

    /// <summary>
    /// Respond flow item view model.
    /// </summary>
    public class RespondFlowItemViewModel : BindableBase
    {
        /// <summary>
        /// The instruction.
        /// </summary>
        private string instruction;

        /// <summary>
        /// The is last instruction.
        /// </summary>
        private bool isLastInstruction;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.Forms.ViewModels.RespondFlowItemViewModel"/> class.
        /// </summary>
        public RespondFlowItemViewModel()
        {
        }

        /// <summary>
        /// Gets or sets the instruction.
        /// </summary>
        /// <value>The instruction.</value>
        public string Instruction
        {
            get { return this.instruction; }
            set { this.SetProperty(ref this.instruction, value); }
        }
               
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:BCP.Forms.ViewModels.RespondFlowItemViewModel"/>
        /// is last instruction.
        /// </summary>
        /// <value><c>true</c> if is last instruction; otherwise, <c>false</c>.</value>
        public bool IsLastInstruction
        {
            get { return this.isLastInstruction; }
            set { this.SetProperty(ref this.isLastInstruction, value); }
        }
    }
}
