﻿/*****************************************************
 * 													 *
 * Asset:		 Touch Controls Kit					 *
 * Script:		 TouchpadSpriteRendererEditor.cs     *
 * 													 *
 * Copyright(c): Victor Klepikov					 *
 * Support: 	 http://bit.ly/vk-Support			 *
 * 													 *
 * mySite:       http://vkdemos.ucoz.org			 *
 * myAssets:     http://u3d.as/5Fb                   *
 * myTwitter:	 http://twitter.com/VictorKlepikov	 *
 * myFacebook:	 http://www.facebook.com/vikle4 	 *
 * 													 *
 ****************************************************/


using UnityEngine;
using UnityEditor;
using TouchControlsKit.Inspector;

namespace TouchControlsKit.SpriteRender.Inspector
{
    [CustomEditor( typeof( TouchpadSpriteRenderer ) )]
    public class TouchpadSpriteRendererEditor : Editor
    {
        private TouchpadSpriteRenderer myTarget = null;


        // OnEnable
        void OnEnable()
        {
            myTarget = ( TouchpadSpriteRenderer )target;

            AxesHelper.HelperSetup( myTarget );
            EventsHelper.HelperSetup( myTarget );
        }

        // OnInspectorGUI
        public override void OnInspectorGUI()
        {
            // BEGIN
            GUILayout.BeginVertical( "Box", GUILayout.Width( 300 ) );
            GUILayout.Space( 5 );
            //

            ShowParameters();
            if( GUI.changed ) EditorUtility.SetDirty( myTarget );

            // END
            GUILayout.Space( 5 );
            GUILayout.EndVertical();
            //
        }

        // ShowParameters
        private void ShowParameters()
        {
            const int size = 115;

            GUILayout.BeginVertical( "Box" );
            GUILayout.Label( "Parameters", StyleHelper.LabelStyle() );
            GUILayout.Space( 5 );

            GUILayout.BeginHorizontal();
            GUILayout.Label( "Anchor", GUILayout.Width( size ) );
            myTarget.myData.Anchor = ( ControllerAnchor )EditorGUILayout.EnumPopup( myTarget.myData.Anchor );
            GUILayout.EndHorizontal();

            GUILayout.Space( 5 );

            GUILayout.BeginHorizontal();
            GUILayout.Label( "Sensitivity", GUILayout.Width( size ) );
            myTarget.sensitivity = EditorGUILayout.Slider( myTarget.sensitivity, 1f, 10f );
            GUILayout.EndHorizontal();

            GUILayout.Space( 5 );

            float minOffsetX = 0f;
            float minOffsetY = 0f;
            if( myTarget.myData.Anchor == ControllerAnchor.LowerCenter || myTarget.myData.Anchor == ControllerAnchor.UpperCenter ) minOffsetX = -50f;
            else if( myTarget.myData.Anchor == ControllerAnchor.MiddleCenter )
            {
                minOffsetX = -50f;
                minOffsetY = -50f;
            }

            GUILayout.BeginHorizontal();
            GUILayout.Label( "Offset X", GUILayout.Width( size ) );
            myTarget.myData.OffsetX = EditorGUILayout.Slider( myTarget.myData.OffsetX, minOffsetX, 50f );
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label( "Offset Y", GUILayout.Width( size ) );
            myTarget.myData.OffsetY = EditorGUILayout.Slider( myTarget.myData.OffsetY, minOffsetY, 50f );
            GUILayout.EndHorizontal();

            GUILayout.Space( 5 );

            GUILayout.BeginHorizontal();
            GUILayout.Label( "Show TouchZone", GUILayout.Width( size ) );
            myTarget.ShowTouchZone = EditorGUILayout.Toggle( myTarget.ShowTouchZone );
            GUILayout.EndHorizontal();

            if( myTarget.ShowTouchZone )
            {
                GUILayout.BeginHorizontal();
                GUILayout.Space( 15 );
                GUILayout.Label( "TouchZone Sprite", GUILayout.Width( size ) );
                myTarget.myData.touchzoneSprite.sprite = EditorGUILayout.ObjectField( myTarget.myData.touchzoneSprite.sprite, typeof( Sprite ), false ) as Sprite;
                GUILayout.EndHorizontal();
            }

            GUILayout.Space( 5 );

            GUILayout.BeginHorizontal();
            GUILayout.Label( "Touchpad Name", GUILayout.Width( 115 ) );
            myTarget.MyName = EditorGUILayout.TextField( myTarget.MyName );
            GUILayout.EndHorizontal();

            GUILayout.Space( 5 );
            GUILayout.EndVertical();

            GUILayout.Space( 5 );
            AxesHelper.ShowAxes( size );
            GUILayout.Space( 5 );
            EventsHelper.ShowEvents( size );  
        }
    }
}