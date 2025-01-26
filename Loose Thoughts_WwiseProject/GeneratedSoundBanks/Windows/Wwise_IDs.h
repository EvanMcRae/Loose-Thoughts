/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID ENEMY1 = 1312765228U;
        static const AkUniqueID ENEMY2 = 1312765231U;
        static const AkUniqueID ENEMY3 = 1312765230U;
        static const AkUniqueID ENEMY4 = 1312765225U;
        static const AkUniqueID LEVEL_1 = 1290008369U;
        static const AkUniqueID LEVEL_2 = 1290008370U;
        static const AkUniqueID LEVEL_3 = 1290008371U;
        static const AkUniqueID MENU_BACK = 3063554414U;
        static const AkUniqueID MENU_TOGGLE = 3546091535U;
        static const AkUniqueID MENUITEM1 = 371673518U;
        static const AkUniqueID MENUITEM2 = 371673517U;
        static const AkUniqueID MENUITEM3 = 371673516U;
        static const AkUniqueID MENUITEM4 = 371673515U;
        static const AkUniqueID MUSIC_TITLE = 3657496341U;
        static const AkUniqueID PAUSE = 3092587493U;
        static const AkUniqueID PLAY_MUSIC = 2932040671U;
        static const AkUniqueID PLAYERDEAD = 2356585300U;
        static const AkUniqueID PLAYERMOVELOOP = 3150453395U;
        static const AkUniqueID PLAYERMOVESTOP = 4168883761U;
        static const AkUniqueID RESUME = 953277036U;
        static const AkUniqueID START_GAME = 1114964412U;
        static const AkUniqueID STOP_ENEMY = 117244396U;
        static const AkUniqueID STOP_MUSIC = 2837384057U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace MUSIC
        {
            static const AkUniqueID GROUP = 3991942870U;

            namespace STATE
            {
                static const AkUniqueID GAMEPLAY = 89505537U;
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID TITLE = 3705726509U;
            } // namespace STATE
        } // namespace MUSIC

    } // namespace STATES

    namespace SWITCHES
    {
        namespace ENEMY
        {
            static const AkUniqueID GROUP = 2299321487U;

            namespace SWITCH
            {
                static const AkUniqueID ENEMY_1 = 1870714583U;
                static const AkUniqueID ENEMY_2 = 1870714580U;
                static const AkUniqueID ENEMY_3 = 1870714581U;
                static const AkUniqueID ENEMY_4 = 1870714578U;
            } // namespace SWITCH
        } // namespace ENEMY

        namespace LEVEL_MUSIC
        {
            static const AkUniqueID GROUP = 1244594577U;

            namespace SWITCH
            {
                static const AkUniqueID L1 = 1702304824U;
                static const AkUniqueID L2 = 1702304827U;
                static const AkUniqueID L3 = 1702304826U;
            } // namespace SWITCH
        } // namespace LEVEL_MUSIC

        namespace UISELECTION
        {
            static const AkUniqueID GROUP = 2454203527U;

            namespace SWITCH
            {
                static const AkUniqueID U1 = 1551306223U;
                static const AkUniqueID U2 = 1551306220U;
                static const AkUniqueID U3 = 1551306221U;
                static const AkUniqueID U4 = 1551306218U;
            } // namespace SWITCH
        } // namespace UISELECTION

    } // namespace SWITCHES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID EMOTIONDISTANCE = 4287271261U;
        static const AkUniqueID MASTERVOLUME = 2918011349U;
        static const AkUniqueID MUSICVOLUME = 2346531308U;
        static const AkUniqueID SOUNDVOLUME = 3873835272U;
    } // namespace GAME_PARAMETERS

    namespace TRIGGERS
    {
        static const AkUniqueID GAME_START = 733168346U;
    } // namespace TRIGGERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MAIN = 3161908922U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
        static const AkUniqueID MUSIC = 3991942870U;
        static const AkUniqueID SFX = 393239870U;
    } // namespace BUSSES

    namespace AUX_BUSSES
    {
        static const AkUniqueID GAMEPLAY_REVERB = 1396213152U;
    } // namespace AUX_BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
