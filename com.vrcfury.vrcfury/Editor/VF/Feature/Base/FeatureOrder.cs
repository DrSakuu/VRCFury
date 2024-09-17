namespace VF.Feature.Base {
    internal enum FeatureOrder {

        CollectExistingComponents,
        CleanupLegacy,

        // Needs to happen before everything
        FixDoubleFx,
        RemoveDefaultControllers,
        RemoveExtraDescriptors,

        // Needs to happen before anything starts using the Animator
        ResetAnimatorBefore,
        
        FixAmbiguousObjectNames,
        
        // Needs to happen before toggles begin getting processed
        ApplyDuringUpload,

        // Needs to be the first thing to instantiate the ControllerManagers
        AnimatorLayerControlRecordBase,
        
        // Needs to happen before any objects are moved, so otherwise the imported
        // animations would not be adjusted to point to the new moved object paths
        FullController,
        
        UpgradeLegacyHaptics,
        GiveEverythingSpsSenders,

        // Needs to run after all haptic components are in place
        // Needs to run before Toggles, because of its "After Bake" action
        BakeHapticPlugs,
        
        ApplyImplicitRestingStates,

        Default,
        // Needs to happen after AdvancedVisemes so that gestures affecting the jaw override visemes
        SenkyGestureDriver,
        // Needs to run after all possible toggles have been created and applied
        CollectToggleExclusiveTags,
        
        // Needs to happen after all controller params (and their types) are in place
        DriveNonFloatTypes,
        
        // Needs to happen after animations are done but before objects start to move
        FixAmbiguousAnimations,

        // Needs to happen after builders have scanned their prop children objects for any purpose (since this action
        // may move objects out of the props and onto the avatar base). One example is the FullController which
        // scans the prop children for contact receivers.
        // This should be basically the only place that "moving objects" happens
        SecurityRestricted, // needs to happen before armature link so that armature linked things can inherit the security restriction
        ArmatureLink,
        WorldConstraintBuilder,

        // Needs to happen after any new skinned meshes have been added
        BoundingBoxFix,
        AnchorOverrideFix,

        // Needs to happen after toggles
        HapticsAnimationRewrites,
        
        // Needs to run after all TPS materials are done
        // Needs to run after toggles are in place
        // Needs to run after HapticsAnimationRewrites
        TpsScaleFix,
        
        FixTouchingContacts,

        // Needs to run after everything else is done messing with rest state
        ApplyToggleRestingState,

        // Finalize Controllers
        UpgradeToVrcConstraints, // Needs to happen before any step starts looking at or cleaning up "invalid" animation bindings
        UnlimitedParameters,
        FixGestureFxConflict, // Needs to run before DirectTreeOptimizer messes with FX parameters
        BlendShapeLinkFixAnimations, // Needs to run after most things are done messing with animations, since it'll make copies of the blendshape curves
        RecordAllDefaults,
        BlendshapeOptimizer, // Needs to run after RecordDefaults
        CleanupEmptyLayers, // Needs to be before anything using EnsureEmptyBaseLayer
        FixUnsetPlayableLayers,
        FixPartiallyWeightedAaps, // Needs to run before PositionDefaultsLayer, before OptimizeBlendTrees, after everything setting AAPs
        PositionDefaultsLayer, // Needs to be right before FixMasks so it winds up at the top of FX, right under the base mask
        FixMasks,
        LocomotionConflictResolver,
        ActionConflictResolver,
        TrackingConflictResolver,
        LayerToTree, // Needs to run after animations are done, including everything that makes its own DBT, including TrackingConflictResolver
        AvoidMmdLayers, // Needs to be after CleanupEmptyLayers (which removes empty layers) and FixMasks and RecordAllDefaults (which may insert layers at the top)
        AdjustWriteDefaults,
        FixEmptyMotions,
        AnimatorLayerControlFix,
        RemoveNonQuestMaterials,
        UpgradeWrongParamTypes,
        TreeFlattening,
        FinalizeController,

        // Finalize Menus
        MoveSpsMenus,
        MoveMenuItems,
        FinalizeMenu,
        FixMipmapStreaming,
        FixAudio,
        FixMenuIconTextures,

        MarkThingsAsDirtyJustInCase,
        
        RemoveJunkAnimators,

        SaveAssets,
        
        // Needs to happen after everything is done using the animator
        ResetAnimatorAfter,
        
        Validation,
        HideAddedComponents,
    }
}
